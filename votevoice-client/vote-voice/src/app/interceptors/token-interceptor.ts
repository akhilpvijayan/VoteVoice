
import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { Observable, catchError, switchMap, throwError } from 'rxjs';
import { AuthService } from '../Auth/auth.service';
import { Router } from '@angular/router';
import { TokenApi } from '../interfaces/token-api';
import { ToastrService } from 'ngx-toastr';
import { MatDialog } from '@angular/material/dialog';

@Injectable()
export class TokenInterceptor implements HttpInterceptor {

  constructor(
    private authService: AuthService, 
    private route: Router,
    private toastr: ToastrService,
  private dialog: MatDialog) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    const token = this.authService.getToken();
    
    if (request.headers.has('X-Skip-Interceptor')) {
      request = request.clone({
        headers: request.headers.delete('X-Skip-Interceptor')
      });
      return next.handle(request);
    }
    else if(token!=null){
      request = request.clone({
        setHeaders: {Authorization: `Bearer ${token}`} //Adding token in header
      });
      return next.handle(request).pipe(
        catchError((err:any)=>{
          if(err instanceof HttpErrorResponse){
            if(err.status === 401){
              return this.handleUnauthError(request, next);
            }
          }
          //this.authService.signOut();
          return throwError(()=> new Error("Unexpected Error occured"));
        })
      );
    }
    return next.handle(request);
    
  }

  handleUnauthError(req: HttpRequest<any>, next: HttpHandler){
    let tokenApi = new TokenApi();
    tokenApi.accessToken = this.authService.getToken()??'';
    tokenApi.refreshToken = this.authService.getRefreshToken()??'';

    return this.authService.renewToken(tokenApi)
    .pipe(
      switchMap((data: TokenApi)=>{
        this.authService.setRefreshToken(data.refreshToken);
        this.authService.setToken(data.accessToken);
        req = req.clone({
          setHeaders: {Authorization: `Bearer ${data.accessToken}`} //Adding token in header
        });
        return next.handle(req);
      }),
      catchError((err)=>{
        return throwError(()=>{
          this.toastr.error("Timeout expired. Login again.");
          this.authService.signOut();
          this.route.navigateByUrl('login');
        })
      })
    )
  }
}

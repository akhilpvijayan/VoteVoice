import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class MiscService {

  constructor(private httpClient: HttpClient) { }

  getAdvice() {
    const headers = new HttpHeaders().set('X-Skip-Interceptor', 'true');
    return this.httpClient.get<any>(`${environment.adviceUrl}`,{ headers });
  }

}

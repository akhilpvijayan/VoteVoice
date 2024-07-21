import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ReloadService {

  private reloadSubject = new Subject<{ componentName: string; data?: any }>();

  reloadComponent(componentName: string, data?: any): void {
    this.reloadSubject.next({ componentName, data });
  }

  getReloadObservable(): Observable<{ componentName: string; data?: any }> {
    return this.reloadSubject;
  }
}
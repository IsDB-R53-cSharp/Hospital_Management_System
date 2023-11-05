import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UnIdenfiedDeadBody } from '../models/un-idenfied-dead-body';


@Injectable({
  providedIn: 'root'
})
export class UnIdenfiedDeadBodyService {

  constructor(private http: HttpClient) { }

  GetAllUnIdenfiedDeadBody(): Observable<any> {
    return this.http.get<any>("http://localhost:5041/api/UnidentifiedDeadBodys");
  }
  PostUnIdenfiedDeadBody(modell: UnIdenfiedDeadBody): Observable<UnIdenfiedDeadBody> {
    return this.http.post<UnIdenfiedDeadBody>("http://localhost:5041/api/UnidentifiedDeadBodys", modell)
  }
  UpdateUnIdenfiedDeadBody(modell: UnIdenfiedDeadBody): Observable<UnIdenfiedDeadBody> {
    return this.http.put<UnIdenfiedDeadBody>("http://localhost:5041/api/UnidentifiedDeadBodys/" + modell.unIdenfiedDeadBodyID, modell);
  }
  DeleteUnIdenfiedDeadBody(id: number): Observable<any> {
    return this.http.delete<any>("http://localhost:5041/api/UnidentifiedDeadBodys/" + id);
  }
}

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Morgue } from '../models/morgue';

@Injectable({
  providedIn: 'root'
})
export class MorgueService {

  constructor(private http: HttpClient) { }

  GetAllMorgue(): Observable<any> {
    return this.http.get<any>("http://localhost:5041/api/Morgue");
  }
  PostMorgue(modell: Morgue): Observable<Morgue> {
    return this.http.post<Morgue>("http://localhost:5041/api/Morgue", modell)
  }
  UpdateMorgue(modell: Morgue): Observable<Morgue> {
    return this.http.put<Morgue>("http://localhost:5041/api/Morgue/" + modell.morgueID, modell);
  }
  DeleteMorgue(id: number): Observable<any> {
    return this.http.delete<any>("http://localhost:5041/api/Morgue/" + id);
  }
}

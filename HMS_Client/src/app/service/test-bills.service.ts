import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TestBills } from '../models/test-bills';

@Injectable({
  providedIn: 'root'
})
export class TestBillsService {

  constructor(private http: HttpClient) { }

  GetAllTestBills(): Observable<any> {
    return this.http.get<any>("http://localhost:5041/api/TestBills");
  }
  PostTestBills(modell: TestBills): Observable<TestBills> {
    return this.http.post<TestBills>("http://localhost:5041/api/TestBills", modell)
  }

  UpdateTestBills(modell: TestBills): Observable<TestBills> {
    return this.http.put<TestBills>("http://localhost:5041/api/TestBills/" + modell.testBillId, modell);
  }

  DeleteTestBills(id: number): Observable<any> {
    return this.http.delete<any>("http://localhost:5041/api/TestBills/" + id);
  }
}

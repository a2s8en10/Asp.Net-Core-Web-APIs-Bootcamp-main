import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class BookService {
  private basePath = 'https://localhost:44369/api/Books';
  private http = inject(HttpClient);

  getAllBook(): Observable<any> {
    return this.http.get<any>(this.basePath);
  }

  addBook(book:any): Observable<any> {
    return this.http.post<any>(this.basePath, book);
  }
}

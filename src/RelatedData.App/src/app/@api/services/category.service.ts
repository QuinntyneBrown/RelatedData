import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Category } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { BASE_URL } from '@core';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(
    @Inject(BASE_URL) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  public get(): Observable<Category[]> {
    return this._client.get<{ categories: Category[] }>(`${this._baseUrl}api/category`)
      .pipe(
        map(x => x.categories)
      );
  }

  public getById(options: { categoryId: string }): Observable<Category> {
    return this._client.get<{ category: Category }>(`${this._baseUrl}api/category/${options.categoryId}`)
      .pipe(
        map(x => x.category)
      );
  }

  public remove(options: { category: Category }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/category/${options.category.categoryId}`);
  }

  public create(options: { category: Category }): Observable<{ category: Category }> {
    return this._client.post<{ category: Category }>(`${this._baseUrl}api/category`, { category: options.category });
  }
  
  public update(options: { category: Category }): Observable<{ category: Category }> {
    return this._client.put<{ category: Category }>(`${this._baseUrl}api/category`, { category: options.category });
  }
}

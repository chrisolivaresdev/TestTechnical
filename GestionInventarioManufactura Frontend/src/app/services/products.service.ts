import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiResponse, Getproduct, Product } from '../interface/interface';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  baseUrl="http://localhost:5001/api"

  constructor(private http: HttpClient) { }

  getPoducts(pageNumber: number, pageSize: number): Observable<Getproduct> {
      let params = new HttpParams()
        .set('pageNumber', pageNumber)
        .set('pageSize', pageSize)
    return this.http.get<Getproduct>(`${this.baseUrl}/Product`, { params });
  }

  getPoductById(id:number): Observable<Product> {
    return this.http.get<Product>(`${this.baseUrl}/Product/${id}`);
  }

  postProducts(produts:Product[]): Observable<ApiResponse> {
    return this.http.post<ApiResponse>(`${this.baseUrl}/Product`, produts);
  }

   updateProduct(id:number, product:Product): Observable<ApiResponse> {
    return this.http.patch<ApiResponse>(`${this.baseUrl}/Product/${id}`, product);
  }

  removeProduct(id:number): Observable<ApiResponse> {
    return this.http.delete<ApiResponse>(`${this.baseUrl}/Product/${id}`);
  }

  changeStatus(id:number): Observable<any> {
    return this.http.patch<ApiResponse>(`${this.baseUrl}/Product/changesStatus/${id}`,{});
  }

}

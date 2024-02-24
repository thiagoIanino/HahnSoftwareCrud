import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Item} from './item.model';


@Injectable({
  providedIn: 'root'
})
export class ItemService {

  private baseURL = 'https://localhost:5000/api'
  private endpoint = 'items'

  constructor(private httpClient: HttpClient) {   }

  list():Observable<Item[]>{
    return this.httpClient.get<Item[]>(`${this.baseURL}/${this.endpoint}`)
  }

  create(item: Item):Observable<Item>{
    return this.httpClient.post<Item>(`${this.baseURL}/${this.endpoint}`, item)
  }

  searchById(id: string):Observable<Item>{
    return this.httpClient.get<Item>(`${this.baseURL}/${this.endpoint}/${id}`)
  }

  update(item: Item):Observable<Item>{
    return this.httpClient.put<Item>(`${this.baseURL}/${this.endpoint}/${item.id}`, item)
  }

  delete(id: number):Observable<{}>{
    return this.httpClient.delete<Item>(`${this.baseURL}/${this.endpoint}/${id}`)
  }
}

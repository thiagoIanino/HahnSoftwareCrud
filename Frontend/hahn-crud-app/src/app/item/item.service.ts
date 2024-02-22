import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Item} from './item.model';


@Injectable({
  providedIn: 'root'
})
export class ItemService {

  private baseURL = 'https://localhost:5000'
  private endpoint = 'itens'

  constructor(private httpClient: HttpClient) {   }

  list():Observable<Item[]>{
    return this.httpClient.get<Item[]>(`${this.baseURL}/${this.endpoint}`)
  }
}

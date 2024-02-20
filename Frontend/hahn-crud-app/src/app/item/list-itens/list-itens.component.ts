import { Component, OnInit } from '@angular/core';
import { ItemService } from '../item.service';
import { Observable } from 'rxjs';
import { Item } from '../item.model';

@Component({
  selector: 'app-list-itens',
  templateUrl: './list-itens.component.html',
  styleUrl: './list-itens.component.scss'
})
export class ListItensComponent implements OnInit {

  itens$!: Observable<Item[]>;
  constructor(private itemService: ItemService){}

  ngOnInit() {
    this.listItens();
  }

  listItens(){
    this.itens$ = this.itemService.list();
  }
}

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ListItensRoutingModule } from './list-itens-routing.module';
import { ListItensComponent } from './list-itens/list-itens.component';


@NgModule({
  declarations: [ListItensComponent],
  imports: [
    CommonModule,
    ListItensRoutingModule
  ]
})
export class ListItensModule { }

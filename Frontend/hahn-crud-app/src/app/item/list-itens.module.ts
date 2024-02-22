import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ListItensRoutingModule } from './list-itens-routing.module';
import { ListItensComponent } from './list-itens/list-itens.component';
import {MatTableModule} from '@angular/material/table'
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner'
import {MatToolbarModule} from '@angular/material/toolbar'

@NgModule({
  declarations: [ListItensComponent],
  imports: [
    CommonModule,
    ListItensRoutingModule,
    MatTableModule,
    MatProgressSpinnerModule,
    MatToolbarModule
  ]
})
export class ListItensModule { }

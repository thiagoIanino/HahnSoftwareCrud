import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListItensComponent } from './list-itens/list-itens.component';

const routes: Routes = [{
  path: "", component: ListItensComponent
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ListItensRoutingModule { }

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateEditItemComponent } from './create-edit-item/create-edit-item.component';

const routes: Routes = [
  {path: "", component: CreateEditItemComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CreateEditItemRoutingModule { }

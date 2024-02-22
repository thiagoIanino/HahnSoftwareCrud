import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateEditItemComponent } from './create-edit-item/create-edit-item.component';
import { ItemResolverService } from './item-resolver.service';

const routes: Routes = [
  {path: "", component: CreateEditItemComponent, resolve:{item: ItemResolverService}}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CreateEditItemRoutingModule { }

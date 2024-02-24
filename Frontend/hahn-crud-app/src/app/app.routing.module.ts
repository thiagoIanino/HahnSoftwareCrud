import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { NgModule } from '@angular/core';

export const routes: Routes = [
    {path:"", component: HomeComponent},
    {path:"items",loadChildren: () => import('./item/list-itens.module').then(module => module.ListItensModule) },
    {path:"items/create",loadChildren: () => import('./item/create-edit-item/create-edit-item.module').then(module => module.CreateEditItemModule) },
    {path:"items/edit/:id",loadChildren: () => import('./item/create-edit-item/create-edit-item.module').then(module => module.CreateEditItemModule) }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class AppRoutingModule{}
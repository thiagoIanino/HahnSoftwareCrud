import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CreateEditItemRoutingModule } from './create-edit-item-routing.module';
import { CreateEditItemComponent } from './create-edit-item/create-edit-item.component';
import { ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';


@NgModule({
  declarations: [CreateEditItemComponent],
  imports: [
    CommonModule,
    CreateEditItemRoutingModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatToolbarModule,
    MatButtonModule
  ]
})
export class CreateEditItemModule { }

import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ItemService } from '../../item.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-edit-item',
  templateUrl: './create-edit-item.component.html',
  styleUrl: './create-edit-item.component.scss'
})
export class CreateEditItemComponent implements OnInit {

  formGroup!: FormGroup;
  constructor(private formBuilder: FormBuilder, private itemService: ItemService, private router: Router) { }

  ngOnInit() {
    this.formGroup = this.formBuilder.group({
      name: ["", Validators.required]
    })}

    save(){
      this.itemService.create(this.formGroup.value).subscribe(
        createdItem => {
          this.router.navigateByUrl("/itens")
        },
        error => {
          alert("Error creating" + JSON.stringify(error));
        }
      )
    }
}

import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ItemService } from '../../item.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Item } from '../../item.model';

@Component({
  selector: 'app-create-edit-item',
  templateUrl: './create-edit-item.component.html',
  styleUrl: './create-edit-item.component.scss'
})
export class CreateEditItemComponent implements OnInit {

  formGroup!: FormGroup;
  item!: Item
  constructor(
    private formBuilder: FormBuilder,
    private itemService: ItemService,
    private router: Router,
    private activeRoute: ActivatedRoute) { }

  ngOnInit() {
    this.item = this.activeRoute.snapshot.data["item"]
    this.formGroup = this.formBuilder.group({
      id: [(this.item && this.item.id) ? this.item.id : null],
      name: [(this.item && this.item.name) ? this.item.name : "", Validators.required],
      quantity: [(this.item && this.item.quantity) ? this.item.quantity : 1, Validators.required]
    })
  }

  save() {
    if (this.item && this.item.id) {
      this.itemService.update(this.formGroup.value).subscribe(
        createdItem => {
          this.router.navigateByUrl("/items")
        },
        error => {
          alert("Error updating: " + error.error.error);
        }
      )
    } else {

      this.itemService.create(this.formGroup.value).subscribe(
        createdItem => {
          this.router.navigateByUrl("/items")
        },
        error => {
          alert("Error creating" + JSON.stringify(error));
        }
      )
    }
  }

  delete() {
    if (confirm("Do you want to delete the item: " + this.item.name + "?")) {
      this.itemService.delete(this.item.id).subscribe(
        response => {
          this.router.navigateByUrl("/items")
        },
        error => {
          alert("Error deleting" + JSON.stringify(error));
        }
      )
    }
  }
}

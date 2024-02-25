import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ItemService } from '../../item.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Item } from '../../item.model';
import { MatDialog } from "@angular/material/dialog";
import { MatSnackBar } from "@angular/material/snack-bar";

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
    private activeRoute: ActivatedRoute,
    public matDialog: MatDialog,
    public matSnackBar: MatSnackBar) { }

  ngOnInit() {
    this.item = this.activeRoute.snapshot.data["item"]
    this.formGroup = this.formBuilder.group({
      id: [(this.item && this.item.id) ? this.item.id : null],
      name: [(this.item && this.item.name) ? this.item.name : "", Validators.required],
      quantity: [(this.item && this.item.quantity) ? this.item.quantity : null, Validators.required]
    })
  }

  save() {
    if (this.item && this.item.id) {
      this.itemService.update(this.formGroup.value).subscribe({
        next: (updatedItem) => {
            this.matSnackBar.open("Successfully updated!", "", {
                duration: 5000,
                panelClass: "green-snackbar",
                verticalPosition: "top"
            });
            this.router.navigateByUrl("/items");
        },
        error: (error) => {
            this.matSnackBar.open(`Error to update: ${error.error.error}`, "", {
                duration: 5000,
                panelClass: "red-snackbar",
                verticalPosition: "top",
                announcementMessage: error.error.error
            });
        },
    });
    } else {

      this.itemService.create(this.formGroup.value).subscribe(
        createdItem => {
          this.router.navigateByUrl("/items")
        },
        error => {
          alert("Error creating: " + error.error.error);
        }
      )
    }
  }

  delete() {
    if (confirm("Do you want to delete the item: " + this.item.name + "?")) {
      this.itemService.delete(this.item.id).subscribe({
        next: (deletedItem) => {
            this.matSnackBar.open("Successfully deleted!", "", {
                duration: 5000,
                panelClass: "green-snackbar",
                verticalPosition: "top"
            });
            this.router.navigateByUrl("/items");
        },
        error: (error) => {
            this.matSnackBar.open(`Error deleting: ${error.error.error}`, "", {
                duration: 5000,
                panelClass: "red-snackbar",
                verticalPosition: "top",
                announcementMessage: error.error.error
            });
        },
    })
    }
  }
}

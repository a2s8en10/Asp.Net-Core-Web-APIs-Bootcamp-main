import { Component, inject } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule } from '@angular/forms';
import { BookService } from '../book.service';

@Component({
  selector: 'app-add-book',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './add-book.component.html',
  styleUrl: './add-book.component.css'
})
export class AddBookComponent {

  public bookForm: FormGroup;

  private formBuilder = inject(FormBuilder);
  private service = inject(BookService);

  // ngOnInit () : void {
  //   this.init();
  // }

  public saveBook() : void {
    this.service.addBook(this.bookForm.value).subscribe(result => {
      alert("new book add with id");
    });
  }
  constructor(private fb: FormBuilder) {
    this.bookForm = this.fb.group({
      title: [],
      author:[]
    });
  // private init(): void {
  //   this.bookForm = this.formBuilder.group({
  //     title:[],
  //     description : []
  //   })

  }

}

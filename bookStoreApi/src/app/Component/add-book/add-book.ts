import { Component, inject} from '@angular/core';
import { BookService } from '../../services/book-service';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, RequiredValidator, Validators } from '@angular/forms';

@Component({
  selector: 'app-add-book',
  imports: [FormsModule, ReactiveFormsModule],
  templateUrl: './add-book.html',
  styleUrl: './add-book.css',
})
export class AddBook {
  bookForm !: FormGroup;
  private bookService = inject(BookService);
  private formBuilder = inject(FormBuilder);

  ngOnInit(): void {
    this.init();
  }

  saveBook(): void {
    this.bookService.addBook(this.bookForm.value).subscribe((result: any) => {
      alert(`Book added successfully = ${result}`);
    });
  }

  init(): void {
    this.bookForm = this.formBuilder.group({
      title: [''],
      description: [''],
    });
  }
}

import { Component, inject } from '@angular/core';
import { BookService } from '../book.service';

@Component({
  selector: 'app-all-books',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './all-books.component.html',
  styleUrl: './all-books.component.css'
})
export class AllBooksComponent {

  public books: any;
  private service = inject(BookService);

  ngOnInit(): void {
    this.getBooks();
  }

  private getBooks() : void {
    this.service.getBooks().subscribe(result => {
      this.books = result;
    })
  }
}import { CommonModule } from '@angular/common';


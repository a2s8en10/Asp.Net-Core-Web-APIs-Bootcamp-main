import { Component, inject } from '@angular/core';
import { BookService } from '../../services/book-service';
import { RouterLink, RouterOutlet } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-all-books',
  imports: [CommonModule],
  templateUrl: './all-books.html',
  styleUrl: './all-books.css',
})  
export class AllBooks {

  books: any;
  private bookService = inject(BookService);

  ngOnInit(): void {
    this.getBookS();
  }

  getBookS(): void {
    this.bookService.getAllBook().subscribe(result =>{
      console.log(result);
      this.books = result;

    });
  }
}

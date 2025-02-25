import { Routes } from '@angular/router';

export const routes: Routes = [
  { path: 'books',
     loadComponent: () => import('./all-books/all-books.component').then(all => all.AllBooksComponent)
  },
  {
    path: "add",
    loadComponent: () => import("./add-book/add-book.component").then(add => add.AddBookComponent)
  }
];

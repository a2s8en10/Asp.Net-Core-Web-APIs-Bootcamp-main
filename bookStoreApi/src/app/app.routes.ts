import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: 'book',
    loadComponent: () =>
      import('./Component/all-books/all-books').then((m) => m.AllBooks),
  },
  {
    path: 'add',
    loadComponent: () =>
      import('./Component/add-book/add-book').then((m) => m.AddBook),
  },
];

import { bootstrapApplication } from '@angular/platform-browser';
import 'bootstrap/dist/css/bootstrap.min.css';
import { appConfig } from './app/app.config';
import { AppComponent } from './app/app.component';

bootstrapApplication(AppComponent, appConfig)
  .catch((err) => console.error(err));

import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http'; 
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component'; 
import { ModalModule } from 'ngx-bootstrap/modal';
import { ContactListComponent } from './contact-list/contact-list.component';
import { RouterModule } from '@angular/router';
import { APP_INITIALIZER, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ContactService } from './Services/contact.service';
import { CreateContactComponent } from './create-contact/create-contact.component'; 
import { TokenService } from './Services/token.service';
import { ConfigProvider } from './Services/UtilsService/config-provider.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent, 
    ContactListComponent,
    CreateContactComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule, 
    FormsModule,
    ReactiveFormsModule,
    ModalModule.forRoot(),
    CommonModule,
    RouterModule.forRoot([
      { path: 'contact-list', component: ContactListComponent, pathMatch: 'full' } 
    ])
  ],
  providers: [
     { provide: 'BASE_URL', useFactory: getBaseUrl, deps: [] },
  ConfigProvider,
  {
    provide: APP_INITIALIZER,
    useFactory: (appConfigProvider: ConfigProvider) => {
      return () => appConfigProvider.loadConfig();
    },
    multi: true,
    deps: [ConfigProvider]
  },ContactService, TokenService,],
  bootstrap: [AppComponent]
})
export class AppModule { }

export function getBaseUrl() {
  return document.getElementsByTagName('base')[0].href;
}

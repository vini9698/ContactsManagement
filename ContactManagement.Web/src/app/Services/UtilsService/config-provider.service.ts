import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';

export declare type AppConfig = { [key: string]: any };

@Injectable()
export class ConfigProvider {
  private _baseUrl: string;
  config!: AppConfig;
  apiUrl: string='';

  constructor(
    private httpClient: HttpClient,
    @Inject('BASE_URL') private baseUrl: string,
  ) {
    this._baseUrl = baseUrl;
  }

  loadConfig() {
    let url = this._baseUrl + 'appsettings.json';
    return this.httpClient.get(url)
      .toPromise()
      .then((response: any) => {
        this.config = response;
      });
  }

  getConfig() {
    return this.config;
  }
}

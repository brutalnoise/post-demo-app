import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";

@Injectable()
export class Configuration {
    private apiBasseUrl = environment.apiBaseUrl;

    public buildEndpoint(urlPath: string): string {
        return `${this.apiBasseUrl}${urlPath}`;
    }   
}
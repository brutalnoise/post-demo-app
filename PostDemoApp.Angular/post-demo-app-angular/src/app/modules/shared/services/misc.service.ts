import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Configuration } from "../constants/configuration";

@Injectable()
export class MiscService {
    protected readonly baseUrl: string;

    constructor(protected readonly http: HttpClient,
        protected readonly configuration: Configuration) {
        this.baseUrl = configuration.buildEndpoint(`Misc/`);
    }

    public RefreshData(): Observable<void> {
        return this.http.get<void>(`${this.baseUrl}RefreshData`);
    }
}
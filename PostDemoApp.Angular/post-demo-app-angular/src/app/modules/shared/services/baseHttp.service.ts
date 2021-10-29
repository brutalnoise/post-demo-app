import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Configuration } from "../constants/configuration";

@Injectable()
export class BaseHttpService<T> {
    protected readonly baseUrl: string;

    constructor(protected readonly http: HttpClient,
        protected readonly configuration: Configuration,
        @Inject(String) protected readonly path: string
        ) {
        this.baseUrl = configuration.buildEndpoint(`${path}/`);
    }

    public GetList(): Observable<T[]> {
        return this.http.get<T[]>(`${this.baseUrl}List`);
    }

    public Get(id: number): Observable<T> {
        return this.http.get<T>(`${this.baseUrl}Get/${id}`);
    }

    public Add(model: T): Observable<T> {
        return this.http.post<T>(`${this.baseUrl}Add`, model);
    }

    public Update(model: T): Observable<T> {
        return this.http.put<T>(`${this.baseUrl}Update`, model);
    }

    public Delete(id: number): Observable<T> {
        return this.http.delete<T>(`${this.baseUrl}Delete/${id}`,);
    }
}
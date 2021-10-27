import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Configuration } from "../../shared/constants/configuration";
import { Observable } from "rxjs";
import { Post } from "../intefraces/post";

@Injectable()
export class PostService {
    private baseUrl: string;

    constructor(private readonly http: HttpClient,
        private readonly configuration: Configuration) {
        this.baseUrl = configuration.buildEndpoint('Post/');
    }

    public GetList(): Observable<Post[]> {
        return this.http.get<Post[]>(`${this.baseUrl}List`);
    }
}
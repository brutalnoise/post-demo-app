import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Configuration } from "../../shared/constants/configuration";
import { Observable } from "rxjs";
import { Comment } from "../intefraces/comment";

@Injectable()
export class CommentService {
    private baseUrl: string;

    constructor(private readonly http: HttpClient,
        private readonly configuration: Configuration) {
        this.baseUrl = configuration.buildEndpoint('Commnet/');
    }

    public GetList(): Observable<Comment[]> {
        return this.http.get<Comment[]>(`${this.baseUrl}List`);
    }
}
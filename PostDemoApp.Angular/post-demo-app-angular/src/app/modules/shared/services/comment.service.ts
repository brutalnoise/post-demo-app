import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Configuration } from "../constants/configuration";
import { Comment } from "../../posts/interfaces/comment";
import { BaseHttpService } from "./baseHttp.service";
import { Observable } from "rxjs";

@Injectable()
export class CommentService extends BaseHttpService<Comment> {

    constructor(protected readonly http: HttpClient,
        protected readonly configuration: Configuration) {
            super(http, configuration, "Comment")
    }

    public GetAllByPostId(postId: number): Observable<Comment[]> {
        return this.http.get<Comment[]>(`${this.baseUrl}GetAllByPostId/${postId}`);
    }
}
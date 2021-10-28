import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Configuration } from "../constants/configuration";
import { Comment } from "../../posts/interfaces/comment";
import { BaseHttpService } from "./baseHttp.service";

@Injectable()
export class CommentService extends BaseHttpService<Comment> {

    constructor(protected readonly http: HttpClient,
        protected readonly configuration: Configuration) {
            super(http, configuration, "Post")
    }
}
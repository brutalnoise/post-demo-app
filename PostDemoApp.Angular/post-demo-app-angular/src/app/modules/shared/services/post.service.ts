import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Configuration } from "../../shared/constants/configuration";
import { Post } from "../../posts/intefraces/post";
import { BaseHttpService } from "../../shared/services/baseHttp.service";

@Injectable()
export class PostService extends BaseHttpService<Post> {

    constructor(protected readonly http: HttpClient,
        protected readonly configuration: Configuration) {
            super(http, configuration, "Post")
    }

}
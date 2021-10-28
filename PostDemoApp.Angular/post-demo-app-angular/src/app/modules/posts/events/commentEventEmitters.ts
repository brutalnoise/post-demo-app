import { Injectable } from "@angular/core";
import { Subject } from "rxjs";
import { Comment } from "../interfaces/comment";

@Injectable()
export class CommentEventEmitters {
    private readonly commentAdded: Subject<Comment> = new Subject();

    public commentAdded$ = this.commentAdded.asObservable();

    public broadcastCommentAdded(comment: Comment) {
        this.commentAdded.next(comment);
    }
}
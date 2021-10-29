import { ChangeDetectionStrategy, Component, EventEmitter, Input, Output } from "@angular/core";
import { Comment } from "../../../interfaces/comment";

@Component({
    selector: 'app-comment-card',
    templateUrl: 'comment-card.component.html',
    styleUrls: [
        'comment-card.component.scss'
    ],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class CommentCardComponent {
    @Input() comment: Comment;
    @Output() onDelete: EventEmitter<Comment> = new EventEmitter();

    constructor() {
        
    }

    deleteComment() {
        this.onDelete.next(this.comment);
    }
}
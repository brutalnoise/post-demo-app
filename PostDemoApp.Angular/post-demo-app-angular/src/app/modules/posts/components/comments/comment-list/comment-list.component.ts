import { ChangeDetectionStrategy, ChangeDetectorRef, Component, EventEmitter, Input, Output } from "@angular/core";
import { Subscription } from "rxjs";
import { CommentService } from "src/app/modules/shared/services/comment.service";
import { CommentEventEmitters } from "../../../events/commentEventEmitters";
import { Comment } from "../../../interfaces/comment";

@Component({
    selector: 'app-comment-list',
    templateUrl: 'comment-list.component.html',
    styleUrls: [
        'comment-list.component.scss'
    ],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class CommentListComponent {
    private subscriptions = new Subscription();

    @Input() postId: number;

    comments: Comment[] = [];
    constructor(private readonly commentService: CommentService,
        private readonly changeDetectorRef: ChangeDetectorRef,
        private readonly commentEventEmitters: CommentEventEmitters) {

    }

    ngOnInit() {
        this.subscriptions.add(this.commentService.GetAllByPostId(this.postId).subscribe(res => {
            this.comments = res;
            this.changeDetectorRef.markForCheck();
        }))

        this.subscriptions.add(this.commentEventEmitters.commentAdded$.subscribe(res => {
            this.comments.unshift(res);

            this.comments = this.comments.slice();
            
            this.changeDetectorRef.markForCheck();
        }))
    }

    ngOnDestroy() {
        this.subscriptions.unsubscribe();
    }

    deleteComment(comment: Comment) {
        this.subscriptions.add(this.commentService.Delete(comment.id).subscribe(res => {
            this.comments = this.comments.filter(p => p.id != comment.id);

            this.changeDetectorRef.markForCheck();
        }));
    }
}
import { ChangeDetectionStrategy, Component, EventEmitter, Input, Output } from "@angular/core";
import { Post } from "../../interfaces/post";

@Component({
    selector: 'tr [app-post-list-entry]',
    templateUrl: 'post-list-entry.component.html',
    styleUrls: [
        'post-list-entry.component.scss'
    ],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class PostListEntryComponent {
    @Input() post: Post;
    @Output() onDelete: EventEmitter<Post> = new EventEmitter();
    @Output() onUpdate: EventEmitter<Post> = new EventEmitter();

    constructor() {
        
    }

    deletePost() {
        this.onDelete.next(this.post);
    }

    updateIsFavourite() {
        this.post.isFavourite = !this.post.isFavourite;
        this.onUpdate.next(this.post);
    }
}
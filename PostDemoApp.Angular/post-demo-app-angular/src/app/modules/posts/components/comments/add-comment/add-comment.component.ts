import { ChangeDetectionStrategy, ChangeDetectorRef, Component, Input } from "@angular/core";
import { FormControl, FormGroup } from "@angular/forms";
import { Subscription } from "rxjs";
import { CommentService } from "src/app/modules/shared/services/comment.service";
import { Validators } from '@angular/forms';
import { CommentPostModel } from "../../../models/commentPostModel";
import { Comment } from "../../../interfaces/comment";
import { CommentEventEmitters } from "../../../events/commentEventEmitters";

@Component({
    selector: 'app-add-comment',
    templateUrl: 'add-comment.component.html',
    styleUrls: ['add-comment.component.scss'],
    changeDetection: ChangeDetectionStrategy.OnPush
})

export class AddCommentComponent {
    private subscriptions = new Subscription();
    
    @Input() postId: number;

    errors: string[] = [];
    addCommentForm = new FormGroup({
        name: new FormControl('', Validators.required),
        email: new FormControl('', { validators: [Validators.required, Validators.email] }),
        body: new FormControl('', Validators.minLength(3))
      });

    constructor(private readonly commentService: CommentService,
        private readonly changeDetectorRef: ChangeDetectorRef,
        private readonly commentEventEmitters: CommentEventEmitters) {
        
    }
    
    ngOnInit() {
       this.subscribeForControlValueChanges('name');
       this.subscribeForControlValueChanges('email');
       this.subscribeForControlValueChanges('body');
    }

    subscribeForControlValueChanges(controlName: string) {
        this.subscriptions.add(this.addCommentForm?.controls?.[controlName].statusChanges.subscribe((v: 'VALID' | 'INVALID') => {
            let err: string[] = [];

            const controlErrors = this.addCommentForm.controls[controlName].errors;

            if(!controlErrors){
              this.errors = [];
              return;
            }

            if(controlErrors['minlength']){
              err.push(`${controlName}minimum length is ${controlErrors['minlength'].requiredLength} symbols`)
            }

            if(controlErrors['required']){
              err.push(`${controlName} is required`)
            }

            if(controlErrors['email']){
              err.push('Please enter valid email.')
            }
      
            this.errors = err
          }))
    }

    onSubmit() {
        if(this.addCommentForm.valid) {
            let comment = new CommentPostModel(this.postId, this.addCommentForm.controls['email'].value, this.addCommentForm.controls['body'].value);
            this.subscriptions.add(this.commentService.Add(comment).subscribe(res => {
                this.commentEventEmitters.broadcastCommentAdded(res);
                this.addCommentForm.reset();
            }))
        }
    }
}
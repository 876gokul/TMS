import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user-service.service';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.css'],
})
export class AddUserComponent implements OnInit {
  constructor(private userService: UserService) { }
  RoleId = 1;

  user: any = {
    id: 0,
    roleId: this.RoleId,
    departmentId: 0,
    name: '',
    userName: '',
    password: '',
    email: '',
    image: '',
  };

  ngOnInit(): void { }

  OnSubmit() {
    console.log(this.user)
    this.userService.postUser(this.user).subscribe(res => {
      console.log(res);
    })
  }

  handleUpload(event: any) {
    const file = event.target.files[0];
    const reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = () => {
      if (reader.result)
        this.user.image = reader.result.toString().replace("data:image/jpeg;base64,", "")
      console.log(this.user.image);
    };
  }
}

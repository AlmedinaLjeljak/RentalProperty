import {Injectable} from "@angular/core";
import {ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot} from "@angular/router";
import {MyAuthService} from "../services/MyAuthService";


@Injectable()
export class AutorizacijaGuardAdministrator implements CanActivate {

  constructor(private router: Router, private myAuthService: MyAuthService) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {

   
    if (this.myAuthService.jelLogiran()) {

      let isAdmin = this.myAuthService.isAdmin();

      if (isAdmin)
      {
        return true;
      }

      this.router.navigate(['LoginPage']);
      return false;
    }


    // not logged in so redirect to login page with the return url
    this.router.navigate(['LoginPage'], { queryParams: { povratniUrl: state.url }});
    return false;
  }
}
import {AutentifikacijaToken} from "../helpers/AutentifikacijaToken";

export interface AuthLoginResponse {
  autentifikacijaToken: AutentifikacijaToken
  isLogiran: boolean
}


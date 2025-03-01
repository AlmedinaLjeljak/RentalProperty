import {AutentifikacijaToken} from "../helpers/auth/AutentifikacijaToken";

export interface AuthLoginResponse {
  autentifikacijaToken: AutentifikacijaToken
  isLogiran: boolean
}


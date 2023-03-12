import { environment } from '../environments/environment';

interface AppConfig {
  API_URL: string;
}

export const config: AppConfig = {
  API_URL: environment.apiUrl,
};

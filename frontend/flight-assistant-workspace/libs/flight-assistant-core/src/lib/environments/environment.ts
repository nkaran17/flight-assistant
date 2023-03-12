const DEFAULTS = {
  name: 'test',
  production: false,
  apiUrl: 'https://localhost:7185',
  version: 'test',
};

export const environment = { ...DEFAULTS, ...(window as any).APP_CONFIG };

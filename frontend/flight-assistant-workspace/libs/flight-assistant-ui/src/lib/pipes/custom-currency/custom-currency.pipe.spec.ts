import { CustomCurrencyPipe } from './custom-currency.pipe';

describe('CustomCurrencyPipe', () => {
  it('create an instance', () => {
    const pipe = new CustomCurrencyPipe(null, null);
    expect(pipe).toBeTruthy();
  });
});

import { CustomAirportPipe } from './custom-airport.pipe';

describe('CustomAirportPipe', () => {
  it('create an instance', () => {
    const pipe = new CustomAirportPipe(null, null);
    expect(pipe).toBeTruthy();
  });
});

import {defer} from './defer';

export const pause = (ms) => defer(null, ms);

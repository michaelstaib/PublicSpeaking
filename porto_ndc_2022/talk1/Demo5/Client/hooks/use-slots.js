import {useContext} from 'react';

import {SlotsContext} from '@/components';

export const useSlots = () => useContext(SlotsContext);

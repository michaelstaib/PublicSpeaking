import {useContext} from 'react';

import {ModeContext} from '@/components';

export const useMode = () => useContext(ModeContext);

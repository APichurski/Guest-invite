import * as React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import { VisitingCard } from './components/VisitingCard';
import { GuestList } from './components/GuestList';
import { SearchGuest } from './components/FindGuest';

export const routes = <Layout>
    <Route exact path='/' component={ VisitingCard } />
    <Route path='/guestList' component={GuestList} />
    <Route path='/search' component={SearchGuest} />
</Layout>;

import * as React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import { VisitingCard } from './components/VisitingCard';
import { FetchData } from './components/FetchData';
import { GuestList } from './components/GuestList';

export const routes = <Layout>
    <Route exact path='/' component={ VisitingCard } />
    <Route path='/counter' component={ GuestList } />
    <Route path='/fetchdata' component={ FetchData } />
</Layout>;

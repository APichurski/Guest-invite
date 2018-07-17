import * as React from 'react';
import { Link, NavLink } from 'react-router-dom';

export class NavMenu extends React.Component<{}, {}> {
    public render() {
        return <div className='main-nav'>
            <div className='navbar navbar-inverse'>
                <div className='navbar-header'>
                    <button type='button' className='navbar-toggle' data-toggle='collapse' data-target='.navbar-collapse'>
                        <span className='sr-only'>Toggle navigation</span>
                        <span className='icon-bar'></span>
                        <span className='icon-bar'></span>
                        <span className='icon-bar'></span>
                    </button>
                    <Link className='navbar-brand ' to={'/'}>Party Maker</Link>
                </div>
                <div className='clearfix'></div>
                <div className='navbar-collapse collapse'>
                    <ul className='nav navbar-nav'>
                        <li>
                            <NavLink to={'/'} exact activeClassName='active'>
                                <span className='glyphicon glyphicon-home'></span> Visiting Card
                            </NavLink>
                        </li>
                        <li>
                            <NavLink to={'/guestList'} activeClassName='active'>
                                <span className='glyphicon glyphicon-education'></span> Guest List
                            </NavLink>
                        </li>
                        <li>
                            <NavLink to={'/search'} activeClassName='active'>
                                <span className='glyphicon glyphicon-th-list'></span> Search guest
                            </NavLink>
                        </li>
                    </ul>
                </div>
            </div>
        </div>;
    }
}
